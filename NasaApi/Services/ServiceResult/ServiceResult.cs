using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NasaApi.Services.ServiceResult
{
    public class ServiceResult
    {
        public List<Violation> Violations { get; }

        public bool HasViolations => Violations.Any();

        public ServiceResult()
        {
            Violations = new List<Violation>();
        }

        public void AddViolation(string message)
        {
            Violations.Add(new Violation(message));
        }

        public void AddViolation(Violation violation)
        {
            Violations.Add(violation);
        }

        public void AddViolation(Exception ex)
        {
            Violations.Add(new Violation(ex));
        }

        public void MergeViolations(List<Violation> violations)
        {
            Violations.AddRange(violations);
        }

        public void MergeViolations(ServiceResult otherResult)
        {
            MergeViolations(otherResult.Violations);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var violation in Violations)
            {
                sb.AppendLine(violation.ToString());
            }

            return sb.ToString();
        }
    }
    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public delegate ServiceResult<T> Factory();
    }
}
