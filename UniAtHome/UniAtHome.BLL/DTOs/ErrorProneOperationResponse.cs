using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace UniAtHome.BLL.DTOs
{
    public abstract class ErrorProneOperationResponse
    {
        private IList<OperationError> errors;

        #region Constructors

        protected ErrorProneOperationResponse()
        {
            errors = new List<OperationError>();
        }

        protected ErrorProneOperationResponse(string error)
        {
            this.errors = new[] { new OperationError(error) };
        }

        protected ErrorProneOperationResponse(IEnumerable<OperationError> errors)
        {
            this.errors = errors?.ToList() ?? new List<OperationError>();
        }

        protected ErrorProneOperationResponse(IEnumerable<IdentityError> errors)
        {
            var errorsEnumeration = 
                errors?.Select(e => new OperationError(e.Description))
                ?? Enumerable.Empty<OperationError>();

            this.errors = errorsEnumeration.ToList();
        }

        #endregion

        [JsonIgnore]
        public bool Success { get => errors == null || errors.Count == 0; }

        [JsonIgnore]
        public IEnumerable<OperationError> Errors
        {
            get => errors;
            set => errors = value.ToList();
        }

        public ErrorProneOperationResponse AddError(string message)
        {
            var error = new OperationError(message);
            errors.Add(error);
            return this;
        }
    }
}
