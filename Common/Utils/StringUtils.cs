using System.Text.RegularExpressions;

namespace Common.Utils
{
    public static class StringUtils
    {
        private const int MaxKeyLength = 50;

        public static string GenerateKey(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Convert to uppercase
            var upper = input.ToUpperInvariant();

            // Replace spaces with underscores
            var underscored = upper.Replace(' ', '_');

            // Remove all non-alphanumeric and underscore characters
            var sanitized = Regex.Replace(underscored, @"[^A-Z0-9_]", string.Empty);

            // Truncate to max allowed length
            return sanitized.Length <= MaxKeyLength
                ? sanitized
                : sanitized.Substring(0, MaxKeyLength);
        }

        public static string Normalize(string input)
        {
            return input?.Trim().ToLowerInvariant().Replace("\u00A0", ""); // remove non-breaking space
        }
    }
}
