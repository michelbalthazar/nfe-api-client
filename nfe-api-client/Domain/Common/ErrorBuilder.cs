using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Err = System.Tuple<string, System.Collections.Generic.IList<string>>;

namespace ServiceInvoice.Domain.Common
{
    /// <summary>
    /// Assists with the validation of input arguments and enforcing of business rules.
    /// Integrates with <see cref="N:System.ComponentModel.DataAnnotations"/> validation.
    /// Can be used as a return value from any method that returns <see cref="Result"/>, <see cref="Result&lt;TSuccess>"/>
    /// or <see cref="Result&lt;TSuccess, TError>"/>.
    /// </summary>
    public partial class ErrorBuilder : List<Err>
    {
        /// <summary>
        /// Returns true if this instance has any errors; otherwise, false.
        /// </summary>
        public bool HasErrors
        {
            get { return this.Count > 0; }
        }

        /// <summary>
        /// Gets or sets a value that indicates if you want to include the first expression (or segment)
        /// in a multi-part member expression (or object path, e.g. param.Property1.Property2),
        /// in the member name when the error is added, when using methods that take a value selector lambda expression
        /// (e.g. <see cref="Add&lt;TMember>(String, Expression&lt;Func&lt;TMember>>)"/>). The default is false.
        /// </summary>
        private bool IncludeValueSelectorFirstKeySegment { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorBuilder"/> class.
        /// </summary>
        public ErrorBuilder() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorBuilder"/> class, using the provided
        /// <paramref name="message"/>.
        /// </summary>
        /// <param name="message">An error message.</param>
        public ErrorBuilder(string message)
        {
            this.Add(message);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorBuilder"/> class, using the provided
        /// <paramref name="message"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="message">An error message.</param>
        /// <param name="value">The value of the tested object.</param>
        public ErrorBuilder(string message, object value)
        {
            Add(message, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorBuilder"/> class, using the provided
        /// <paramref name="message"/>, <paramref name="value"/> and <paramref name="key"/>.
        /// </summary>
        /// <param name="message">An error message.</param>
        /// <param name="value">The value of the tested object.</param>
        /// <param name="key">The key that identifies the tested object, e.g. a property name.</param>
        public ErrorBuilder(string message, object value, string key)
        {
            this.Add(message, value, key);
        }

        /// <summary>
        /// Adds <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>A reference to this instance after the add operation has completed.</returns>
        public ErrorBuilder Add(string message)
        {
            return this.Add(message, null);
        }

        /// <summary>
        /// Adds <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="value">The value of the tested object.</param>
        /// <returns>A reference to this instance after the add operation has completed.</returns>
        public ErrorBuilder Add(string message, object value)
        {
            return this.Add(message, value, null);
        }

        /// <summary>
        /// Adds <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="value">The value of the tested object.</param>
        /// <param name="key">The key that identifies the tested object, e.g. a property name.</param>
        /// <returns>A reference to this instance after the add operation has completed.</returns>
        public ErrorBuilder Add(string message, object value, string key)
        {
            if (message == null) throw new ArgumentNullException("message");

            this.AddError(message, value, key, (key != null) ? new[] { key } : null);

            return this;
        }

        /// <summary>
        /// Adds <paramref name="message"/>.
        /// </summary>
        /// <typeparam name="TMember">The type of the tested object.</typeparam>
        /// <param name="message">The error message.</param>
        /// <param name="valueSelector">A lambda expression that returns the tested object.</param>
        /// <returns>A reference to this instance after the add operation has completed.</returns>
        //[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "For use with lambda expressions.")]
        //public ErrorBuilder Add<TMember>(string message, Expression<Func<TMember>> valueSelector)
        //{
        //    if (message == null) throw new ArgumentNullException("message");
        //    if (valueSelector == null) throw new ArgumentNullException("valueSelector");

        //    string fullKey = NameOf(valueSelector, this.IncludeValueSelectorFirstKeySegment);
        //    string key = fullKey.Split('.').Last();
        //    object value = valueSelector.Compile().Invoke();

        //    MemberExpression memberExpr = valueSelector.Body as MemberExpression;

        //    if (memberExpr != null)
        //    {
        //        key = GetDisplayName(memberExpr.Member) ?? key;
        //    }

        //    this.AddError(message, value, key, new[] { fullKey });

        //    return this;
        //}

        //static string GetDisplayName(MemberInfo member)
        //{
        //    var displayAttr = member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

        //    if (displayAttr != null)
        //    {
        //        return displayAttr.GetName();
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// Adds the validation result.
        ///// </summary>
        ///// <param name="validationResult">The validation result to add.</param>
        ///// <returns>A reference to this instance after the add operation has completed.</returns>
        //public ErrorBuilder Add(ValidationResult validationResult)
        //{
        //    if (validationResult == null) throw new ArgumentNullException("validationResult");

        //    this.AddError(validationResult.ErrorMessage, validationResult.MemberNames);

        //    return this;
        //}

        ///// <summary>
        ///// Adds the validation results.
        ///// </summary>
        ///// <param name="validationResults">The validation results to add.</param>
        ///// <returns>A reference to this instance after the add range operation has completed.</returns>
        //public ErrorBuilder AddRange(IEnumerable<ValidationResult> validationResults)
        //{
        //    if (validationResults == null) throw new ArgumentNullException("validationResults");

        //    foreach (var item in validationResults)
        //    {
        //        this.Add(item);
        //    }

        //    return this;
        //}

        private void AddError(string message, IEnumerable<string> memberNames)
        {
            this.Add(new Err(message, new Collection<string>((memberNames ?? new string[0]).ToList())));
        }

        private void AddError(string message, object value, string key, IEnumerable<string> memberNames)
        {
            this.AddError(string.Format(CultureInfo.InvariantCulture, message, value, key), memberNames);
        }

        /// <summary>
        /// Adds <paramref name="message"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="condition">
        /// The conditional expression to evaluate. If the condition is true the <paramref name="message"/>
        /// is not added.
        /// </param>
        /// <param name="message">The error message.</param>
        /// <returns>The value of <paramref name="condition"/>.</returns>
        public bool Assert(bool condition, string message)
        {

            if (!condition)
            {
                this.Add(message);
            }

            return condition;
        }

        /// <summary>
        /// Adds <paramref name="message"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="condition">
        /// The conditional expression to evaluate. If the condition is true the <paramref name="message"/>
        /// is not added.
        /// </param>
        /// <param name="message">The error message.</param>
        /// <param name="value">The value of the tested object.</param>
        /// <returns>The value of <paramref name="condition"/>.</returns>
        public bool Assert(bool condition, string message, object value)
        {
            if (!condition)
            {
                this.Add(message, value);
            }

            return condition;
        }

        /// <summary>
        /// Adds <paramref name="message"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="condition">
        /// The conditional expression to evaluate. If the condition is true the <paramref name="message"/>
        /// is not added.
        /// </param>
        /// <param name="message">The error message.</param>
        /// <param name="value">The value of the tested object.</param>
        /// <param name="key">The key that identifies the tested object, e.g. a property name.</param>
        /// <returns>The value of <paramref name="condition"/>.</returns>
        public bool Assert(bool condition, string message, object value, string key)
        {
            if (!condition)
            {
                this.Add(message, value, key);
            }

            return condition;
        }

        /// <summary>
        /// Adds <paramref name="message"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <typeparam name="TMember">The type of the tested object.</typeparam>
        /// <param name="condition">
        /// The conditional expression to evaluate. If the condition is true the <paramref name="message"/>
        /// is not added.
        /// </param>
        /// <param name="message">The error message.</param>
        /// <param name="valueSelector">A lambda expression that returns the tested object.</param>
        /// <returns>The value of <paramref name="condition"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "For use with lambda expressions.")]
        public bool Assert<TMember>(bool condition, string message, Expression<Func<TMember>> valueSelector)
        {
            if (!condition)
            {
                this.Add(message, valueSelector);
            }

            return condition;
        }

        /// <summary>
        /// Adds <paramref name="message"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="condition">
        /// The conditional expression to evaluate. If the condition is true the <paramref name="message"/>
        /// is not added.
        /// </param>
        /// <param name="message">The error message.</param>
        /// <returns>The negated value of <paramref name="condition"/>.</returns>
        public bool Not(bool condition, string message)
        {
            return !this.Assert(condition, message);
        }

        /// <summary>
        /// Adds <paramref name="message"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="condition">
        /// The conditional expression to evaluate. If the condition is true the <paramref name="message"/>
        /// is not added.
        /// </param>
        /// <param name="message">The error message.</param>
        /// <param name="value">The value of the tested object.</param>
        /// <returns>The negated value of <paramref name="condition"/>.</returns>
        public bool Not(bool condition, string message, object value)
        {
            return !this.Assert(condition, message, value);
        }

        /// <summary>
        /// Adds <paramref name="message"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="condition">
        /// The conditional expression to evaluate. If the condition is true the <paramref name="message"/>
        /// is not added.
        /// </param>
        /// <param name="message">The error message.</param>
        /// <param name="value">The value of the tested object.</param>
        /// <param name="key">The key that identifies the tested object, e.g. a property name.</param>
        /// <returns>The negated value of <paramref name="condition"/>.</returns>
        public bool Not(bool condition, string message, object value, string key)
        {
            return !this.Assert(condition, message, value, key);
        }

        /// <summary>
        /// Adds <paramref name="message"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <typeparam name="TMember">The type of the tested object.</typeparam>
        /// <param name="condition">
        /// The conditional expression to evaluate. If the condition is true the <paramref name="message"/>
        /// is not added.
        /// </param>
        /// <param name="message">The error message.</param>
        /// <param name="valueSelector">A lambda expression that returns the tested object.</param>
        /// <returns>The negated value of <paramref name="condition"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "For use with lambda expressions.")]
        public bool Not<TMember>(bool condition, string message, Expression<Func<TMember>> valueSelector)
        {
            return !this.Assert<TMember>(condition, message, valueSelector);
        }

        /// <summary>
        /// Invokes Data Annotations validation and adds the validation results.
        /// </summary>
        /// <param name="value">The obejct to validate.</param>
        /// <returns>true if the object is valid; otherwise false.</returns>
        //public bool Valid(object value)
        //{
        //    var validation = new List<ValidationResult>();
        //    var context = new ValidationContext(value, null, null);

        //    bool valid = Validator.TryValidateObject(value, context, validation, validateAllProperties: true);

        //    this.AddRange(validation);

        //    return valid;
        //}

        /// <summary>
        /// Invokes Data Annotations validation and adds the validation results.
        /// </summary>
        /// <param name="value">The obejct to validate.</param>
        /// <returns>true if the object is not valid; otherwise false.</returns>
        //public bool NotValid(object value)
        //{
        //    return !this.Valid(value);
        //}

        /// <summary>
        /// Invokes Data Annotations validation and adds the validation results.
        /// </summary>
        /// <typeparam name="T">The type of objects to validate.</typeparam>
        /// <param name="values">The objects to validate.</param>
        /// <returns>true if all object are valid; otherwise false.</returns>
        //public bool ValidAll<T>(IList<T> values)
        //{
        //    if (values == null) throw new ArgumentNullException("values");

        //    bool valid = true;

        //    for (int i = 0; i < values.Count; i++)
        //    {

        //        var validation = new List<ValidationResult>();
        //        object obj = values[i];
        //        bool objValid = Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), validation, validateAllProperties: true);
        //        string baseName = String.Concat("[", i.ToString(CultureInfo.InvariantCulture), "].");

        //        for (int j = 0; j < validation.Count; j++)
        //        {
        //            ValidationResult valResult = validation[j];

        //            this.AddError(valResult.ErrorMessage, valResult.MemberNames.Select(n => baseName + n));
        //        }

        //        if (valid)
        //        {
        //            valid = objValid;
        //        }
        //    }

        //    return valid;
        //}

        /// <summary>
        /// Invokes Data Annotations validation and adds the validation results.
        /// </summary>
        /// <typeparam name="T">The type of objects to validate.</typeparam>
        /// <param name="values">The objects to validate.</param>
        /// <returns>true if one or more objects are not valid; otherwise false.</returns>
        //public bool NotValidAll<T>(IList<T> values)
        //{
        //    return !this.ValidAll(values);
        //}

        /// <summary>
        /// Invokes Data Annotations validation and adds the validation results.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property to validate.</typeparam>
        /// <param name="propertySelector">A lambda expression that returns the property to validate.</param>
        /// <returns>true if the property is valid; otherwise false.</returns>
        //[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "For use with lambda expressions.")]
        //public bool ValidProperty<TProperty>(Expression<Func<TProperty>> propertySelector)
        //{

        //    if (propertySelector == null) throw new ArgumentNullException("propertySelector");

        //    MemberExpression memberExpr = (MemberExpression)propertySelector.Body;
        //    string propertyName = memberExpr.Member.Name;
        //    TProperty propertyValue = propertySelector.Compile().Invoke();
        //    object instance = Expression.Lambda(memberExpr.Expression).Compile().DynamicInvoke();

        //    var validation = new List<ValidationResult>();

        //    var context = new ValidationContext(instance, null, null)
        //    {
        //        MemberName = propertyName
        //    };

        //    bool valid = Validator.TryValidateProperty(propertyValue, context, validation);

        //    this.AddRange(validation);

        //    return valid;
        //}

        /// <summary>
        /// Invokes Data Annotations validation and adds the validation results.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property to validate.</typeparam>
        /// <param name="propertySelector">A lambda expression that returns the property to validate.</param>
        /// <returns>true if the property is not valid; otherwise false.</returns>
        //[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "For use with lambda expressions.")]
        //public bool NotValidProperty<TProperty>(Expression<Func<TProperty>> propertySelector)
        //{
        //    return !ValidProperty<TProperty>(propertySelector);
        //}

        /// <summary>
        /// Returns a list of all errors added to this instance so far.
        /// </summary>
        /// <returns>A list of all errors added to this instance so far.</returns>
        public IList<ValidationResult> GetErrors()
        {
            var list = this.Select(e => new ValidationResult(e.Item1, e.Item2))
                              .ToArray();

            return new ErrCollection(this.ToString(), list);
        }

        /// <summary>
        /// Returns the main error message, or an empty string if this instance contains no errors.
        /// </summary>
        /// <returns>The main error message, or an empty string if this instance contains no errors.</returns>
        public override string ToString()
        {

            return
               (from e in this
                where e.Item2.Count == 0
                   || e.Item2.Contains("")
                select e.Item1)
               .FirstOrDefault()
               ?? "";
        }

        static string NameOf(LambdaExpression valueSelector, bool includeFirstKeySegment = false)
        {
            List<string> segments = new List<string>();

            Expression body = valueSelector.Body;

            while (body != null)
            {

                if (body.NodeType == ExpressionType.Call)
                {

                    MethodCallExpression callExpr = (MethodCallExpression)body;
                    segments.Add(GetIndexerExpression(callExpr.Arguments.Single()));
                    body = callExpr.Object;

                }
                else
                {

                    if (body.NodeType == ExpressionType.ArrayIndex)
                    {

                        BinaryExpression binaryExpr = (BinaryExpression)body;
                        segments.Add(GetIndexerExpression(binaryExpr.Right));
                        body = binaryExpr.Left;

                        continue;
                    }

                    if (body.NodeType == ExpressionType.MemberAccess)
                    {

                        MemberExpression memberExpr = (MemberExpression)body;
                        segments.Add("." + memberExpr.Member.Name);
                        body = memberExpr.Expression;

                        continue;
                    }

                    body = null;
                }
            }

            if (segments.Count == 0)
            {
                return "";
            }

            segments.Reverse();

            if (!includeFirstKeySegment)
            {
                segments.RemoveAt(0);
            }

            return String.Join("", segments).TrimStart('.');
        }

        static string GetIndexerExpression(Expression expression)
        {
            Expression body = Expression.Convert(expression, typeof(object));
            var lambdaExpression = Expression.Lambda<Func<object>>(body);

            Func<object> func = lambdaExpression.Compile();

            return String.Concat("[", Convert.ToString(func(), CultureInfo.InvariantCulture), "]");
        }

        internal class ErrCollection : Collection<ValidationResult>
        {
            private readonly string _message;

            public ErrCollection(string message, IList<ValidationResult> list)
                : base(list)
            {

                _message = message;
            }

            public override string ToString()
            {
                return _message;
            }

            public string Error
            {
                get { return ToString(); }
            }

            public string this[string columnName]
            {
                get
                {
                    return
                       (from e in this
                        where e.MemberNames.Contains(columnName, StringComparer.Ordinal)
                        select e.ErrorMessage)
                       .FirstOrDefault();
                }
            }
        }
    }

    public class ValidationResult
    {
        #region Member Fields

        private IEnumerable<string> _memberNames;
        private string _errorMessage;

        /// <summary>
        /// Gets a <see cref="ValidationResult"/> that indicates Success.
        /// </summary>
        /// <remarks>
        /// The <c>null</c> value is used to indicate success.  Consumers of <see cref="ValidationResult"/>s
        /// should compare the values to <see cref="ValidationResult.Success"/> rather than checking for null.
        /// </remarks>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "We want this to be readonly since we're just returning null")]
        public static readonly ValidationResult Success;

        #endregion

        #region All Constructors

        /// <summary>
        /// Constructor that accepts an error message.  This error message would override any error message
        /// provided on the <see cref="ValidationAttribute"/>.
        /// </summary>
        /// <param name="errorMessage">The user-visible error message.  If null, <see cref="ValidationAttribute.GetValidationResult"/>
        /// will use <see cref="ValidationAttribute.FormatErrorMessage"/> for its error message.</param>
        public ValidationResult(string errorMessage)
            : this(errorMessage, null)
        {
        }

        /// <summary>
        /// Constructor that accepts an error message as well as a list of member names involved in the validation.
        /// This error message would override any error message provided on the <see cref="ValidationAttribute"/>.
        /// </summary>
        /// <param name="errorMessage">The user-visible error message.  If null, <see cref="ValidationAttribute.GetValidationResult"/> 
        /// will use <see cref="ValidationAttribute.FormatErrorMessage"/> for its error message.</param>
        /// <param name="memberNames">The list of member names affected by this result.
        /// This list of member names is meant to be used by presentation layers to indicate which fields are in error.</param>
        public ValidationResult(string errorMessage, IEnumerable<string> memberNames)
        {
            this._errorMessage = errorMessage;
            this._memberNames = memberNames ?? new string[0];
        }

#if !SILVERLIGHT
        /// <summary>
        /// Constructor that creates a copy of an existing ValidationResult.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="validationResult"/> is null.</exception>
        protected ValidationResult(ValidationResult validationResult)
        {
            if (validationResult == null)
            {
                throw new ArgumentNullException("validationResult");
            }

            this._errorMessage = validationResult._errorMessage;
            this._memberNames = validationResult._memberNames;
        }
#endif
        #endregion

        #region Properties

        /// <summary>
        /// Gets the collection of member names affected by this result.  The collection may be empty but will never be null.
        /// </summary>
        public IEnumerable<string> MemberNames
        {
            get
            {
                return this._memberNames;
            }
        }

        /// <summary>
        /// Gets the error message for this result.  It may be null.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                this._errorMessage = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Override the string representation of this instance, returning
        /// the <see cref="ErrorMessage"/> if not <c>null</c>, otherwise
        /// the base <see cref="Object.ToString"/> result.
        /// </summary>
        /// <remarks>
        /// If the <see cref="ErrorMessage"/> is empty, it will still qualify
        /// as being specified, and therefore returned from <see cref="ToString"/>.
        /// </remarks>
        /// <returns>The <see cref="ErrorMessage"/> property value if specified,
        /// otherwise, the base <see cref="Object.ToString"/> result.</returns>
        public override string ToString()
        {
            return this.ErrorMessage ?? base.ToString();
        }

        #endregion Methods

    }
}
