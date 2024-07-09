using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InValidCredentials => Error.Validation(
            code: "Auth.InValidCredentials",
            description: "InValidCredentials.");
    }
}
