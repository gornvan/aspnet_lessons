/* 
 * webapi
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// DateOnly
    /// </summary>
    [DataContract]
        public partial class DateOnly :  IEquatable<DateOnly>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateOnly" /> class.
        /// </summary>
        /// <param name="year">year.</param>
        /// <param name="month">month.</param>
        /// <param name="day">day.</param>
        /// <param name="dayOfWeek">dayOfWeek.</param>
        public DateOnly(int? year = default(int?), int? month = default(int?), int? day = default(int?), DayOfWeek dayOfWeek = default(DayOfWeek))
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.DayOfWeek = dayOfWeek;
        }
        
        /// <summary>
        /// Gets or Sets Year
        /// </summary>
        [DataMember(Name="year", EmitDefaultValue=false)]
        public int? Year { get; set; }

        /// <summary>
        /// Gets or Sets Month
        /// </summary>
        [DataMember(Name="month", EmitDefaultValue=false)]
        public int? Month { get; set; }

        /// <summary>
        /// Gets or Sets Day
        /// </summary>
        [DataMember(Name="day", EmitDefaultValue=false)]
        public int? Day { get; set; }

        /// <summary>
        /// Gets or Sets DayOfWeek
        /// </summary>
        [DataMember(Name="dayOfWeek", EmitDefaultValue=false)]
        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Gets or Sets DayOfYear
        /// </summary>
        [DataMember(Name="dayOfYear", EmitDefaultValue=false)]
        public int? DayOfYear { get; private set; }

        /// <summary>
        /// Gets or Sets DayNumber
        /// </summary>
        [DataMember(Name="dayNumber", EmitDefaultValue=false)]
        public int? DayNumber { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DateOnly {\n");
            sb.Append("  Year: ").Append(Year).Append("\n");
            sb.Append("  Month: ").Append(Month).Append("\n");
            sb.Append("  Day: ").Append(Day).Append("\n");
            sb.Append("  DayOfWeek: ").Append(DayOfWeek).Append("\n");
            sb.Append("  DayOfYear: ").Append(DayOfYear).Append("\n");
            sb.Append("  DayNumber: ").Append(DayNumber).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DateOnly);
        }

        /// <summary>
        /// Returns true if DateOnly instances are equal
        /// </summary>
        /// <param name="input">Instance of DateOnly to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DateOnly input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Year == input.Year ||
                    (this.Year != null &&
                    this.Year.Equals(input.Year))
                ) && 
                (
                    this.Month == input.Month ||
                    (this.Month != null &&
                    this.Month.Equals(input.Month))
                ) && 
                (
                    this.Day == input.Day ||
                    (this.Day != null &&
                    this.Day.Equals(input.Day))
                ) && 
                (
                    this.DayOfWeek == input.DayOfWeek ||
                    (this.DayOfWeek != null &&
                    this.DayOfWeek.Equals(input.DayOfWeek))
                ) && 
                (
                    this.DayOfYear == input.DayOfYear ||
                    (this.DayOfYear != null &&
                    this.DayOfYear.Equals(input.DayOfYear))
                ) && 
                (
                    this.DayNumber == input.DayNumber ||
                    (this.DayNumber != null &&
                    this.DayNumber.Equals(input.DayNumber))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Year != null)
                    hashCode = hashCode * 59 + this.Year.GetHashCode();
                if (this.Month != null)
                    hashCode = hashCode * 59 + this.Month.GetHashCode();
                if (this.Day != null)
                    hashCode = hashCode * 59 + this.Day.GetHashCode();
                if (this.DayOfWeek != null)
                    hashCode = hashCode * 59 + this.DayOfWeek.GetHashCode();
                if (this.DayOfYear != null)
                    hashCode = hashCode * 59 + this.DayOfYear.GetHashCode();
                if (this.DayNumber != null)
                    hashCode = hashCode * 59 + this.DayNumber.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
