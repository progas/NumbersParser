namespace WritingNumbers
{
    /// <summary>
    /// Determines name of the part of float number
    /// </summary>
    public class NumberPartName
    {
        /// <summary>
        /// Singular name
        /// </summary>
        private readonly string singularName;

        /// <summary>
        /// Plural name
        /// </summary>
        private readonly string pluralName;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="singularName">Singular name</param>
        /// <param name="pluralName">Plural name</param>
        public NumberPartName(string singularName, string pluralName ="")
        {
            this.singularName = singularName;
            this.pluralName = string.IsNullOrEmpty(pluralName) ? singularName : pluralName;
        }

        /// <summary>
        /// Singular or plural number's name
        /// </summary>
        /// <param name="number">Number in digits</param>
        /// <returns>Name</returns>
        public string GetNumberName(string number)
        {
            if(!string.IsNullOrEmpty(number))
            {
                return this.NumberIsSingular(number) ? this.singularName : this.pluralName;
            }

            return this.singularName;
        }

        /// <summary>
        /// Check number if singular or plural
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>Is singular</returns>
        protected virtual bool NumberIsSingular(string number)
        {
            long parsedValue;
            if (long.TryParse(number, out parsedValue))
            {
                return parsedValue == 1;
            }

            return false;
        }
    }
}
