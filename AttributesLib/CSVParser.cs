using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace AttributesLib {
    public class CSVParser {
        public string FilePath { get; }

        public CSVParser(string filePath) {
            FilePath = filePath;
        }
        
        public string GetData(int row, int field) {
            using var parser =
                new TextFieldParser(FilePath) {
                    TextFieldType = FieldType.Delimited,
                    Delimiters = new[] {","},
                    TrimWhiteSpace = true,
                    HasFieldsEnclosedInQuotes = true
                };

            var currentRow = 0;
            while(!parser.EndOfData) {
                if(currentRow == row) {
                    var fields = parser.ReadFields();
                    return fields.ElementAtOrDefault(field);
                }

                parser.ReadLine();
                ++currentRow;
            }

            return null;
        }
    }
}