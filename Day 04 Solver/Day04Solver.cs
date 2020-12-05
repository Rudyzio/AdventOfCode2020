using System.Collections.Generic;
using System.Linq;

namespace Day_04_Solver
{
    public static class Day04Solver
    {
        public static int Part1Solution(string[] lines)
        {
            int validPassports = 0;
            var passports = ParsePassports(lines);
            foreach (var pass in passports)
            {
                if (pass.IsFormatValid())
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

        public static int Part2Solution(string[] lines)
        {
            int validPassports = 0;
            var passports = ParsePassports(lines);
            foreach (var pass in passports)
            {
                if (pass.IsValueValid())
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

        private static List<Passport> ParsePassports(string[] lines) {
            List<Passport> passports = new List<Passport>();
            Passport passport = new Passport();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    passports.Add(passport);
                    passport = new Passport();
                    continue;
                }

                var passportFields = line.Split(" ");
                foreach (var passportField in passportFields)
                {
                    passport.AddField(passportField);
                }
            }
            // Last line! Needs to add it here or it will be missing!!!
            passports.Add(passport);

            return passports;
        }
    }

    public class Passport
    {
        public Passport()
        {
            PassportFields = new List<PassportField>();
        }

        public List<PassportField> PassportFields { get; set; }

        public void AddField(string pair)
        {
            var splitted = pair.Split(":");
            PassportFields.Add(new PassportField
            {
                Key = splitted[0],
                Value = splitted[1]
            });
        }

        public bool IsFormatValid()
        {
            return (PassportFields.Any(x => x.Key.Equals("byr")) &&
                   PassportFields.Any(x => x.Key.Equals("iyr")) &&
                   PassportFields.Any(x => x.Key.Equals("eyr")) &&
                   PassportFields.Any(x => x.Key.Equals("hgt")) &&
                   PassportFields.Any(x => x.Key.Equals("hcl")) &&
                   PassportFields.Any(x => x.Key.Equals("ecl")) &&
                   PassportFields.Any(x => x.Key.Equals("pid")));
        }

        public bool IsValueValid()
        {
            return (PassportFields.Any(x => x.Key.Equals("byr") && (int.Parse(x.Value) >= 1920 && int.Parse(x.Value) <= 2002)) &&
                   PassportFields.Any(x => x.Key.Equals("iyr") && (int.Parse(x.Value) >= 2010 && int.Parse(x.Value) <= 2020)) &&
                   PassportFields.Any(x => x.Key.Equals("eyr") && (int.Parse(x.Value) >= 2020 && int.Parse(x.Value) <= 2030)) &&
                   PassportFields.Any(x => x.Key.Equals("hcl") && (x.Value.StartsWith("#") &&
                                                                   x.Value.Length == 7 &&
                                                                   x.Value[1..].All(c => "0123456789abcdef".IndexOf(c) >= 0))) &&
                   PassportFields.Any(x => x.Key.Equals("hgt") && ((x.Value.Contains("cm") && int.Parse(x.Value[0..^2]) >= 150 && int.Parse(x.Value[0..^2]) <= 193) 
                                                                    ||
                                                                    (x.Value.Contains("in") && int.Parse(x.Value[0..^2]) >= 59 && int.Parse(x.Value[0..^2]) <= 76)
                                                                   )) && 
                   PassportFields.Any(x => x.Key.Equals("ecl") && new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(x.Value)) &&
                   PassportFields.Any(x => x.Key.Equals("pid") && x.Value.Length == 9));
        }
    }

    public class PassportField
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Key}:{Value}";
        }
    }
}
