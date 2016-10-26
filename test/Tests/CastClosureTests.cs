using System;
using System.Linq;
using System.Linq.Expressions;
using EfCastClosure.Domain;
using Xunit;
using Xunit.Abstractions;

namespace EfCastClosure.Tests
{
    public class CastClosureTests : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly FooContext _db;

        public CastClosureTests(ITestOutputHelper output)
        {
            _output = output;
            _db = new FooContext();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        [Fact]
        public void ImplicitCast()
        {
            var foos = _db.Foos.Where(f => f.String == new Bar(1337));

            _output.WriteLine(((MethodCallExpression)foos.Expression).Arguments[1].ToString());

            foos.Count();
        }

        [Fact]
        public void AccessPropertyOfClosure()
        {
            var bar = new Bar(1337);
            var foos = _db.Foos.Where(f => f.String == bar.Value);

            _output.WriteLine(((MethodCallExpression)foos.Expression).Arguments[1].ToString());

            foos.Count();
        }

        [Fact]
        public void CallMethodOnClosure()
        {
            var bar = new Bar(1337);
            var foos = _db.Foos.Where(f => f.String == bar.ToString());

            _output.WriteLine(((MethodCallExpression)foos.Expression).Arguments[1].ToString());

            foos.Count();
        }

        [Fact] // FAILS
        public void ImplicitlyCastClosure()
        {
            var bar = new Bar(1337);
            var foos = _db.Foos.Where(f => f.String == bar);

            _output.WriteLine(((MethodCallExpression)foos.Expression).Arguments[1].ToString());

            foos.Count();
        }

        [Fact] // FAILS
        public void ImplicitlyCastReturnValue()
        {
            var foos = _db.Foos.Where(f => f.String == new Bar(1337).Clone());

            _output.WriteLine(((MethodCallExpression)foos.Expression).Arguments[1].ToString());

            foos.Count();
        }
    }
}
