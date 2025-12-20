using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string? Error { get; private set; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string? error)
        {
            if (isSuccess && error != null)
                throw new InvalidOperationException();
            if (!isSuccess && error == null)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Ok() => new Result(true, null);
        public static Result Fail(string error) => new Result(false, error);
    }

    
    public class Result<T> : Result
    {
        public T? Value { get; private set; }

        protected internal Result(T value) : base(true, null)
        {
            Value = value;
        }

        protected internal Result(string error) : base(false, error) { }

        public static Result<T> Ok(T value) => new Result<T>(value);
        public static new Result<T> Fail(string error) => new Result<T>(error);
    }
}
