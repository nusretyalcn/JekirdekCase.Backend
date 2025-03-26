using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects
{
    public class LogAspect : MethodInterception
    {
        public LogAspect()
        {
            Log.Logger = new LoggerConfiguration()
                
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}";
            var arguments = string.Join(", ", invocation.Arguments);
            Log.Information("[LOG] OnBefore -> {Method} | Arguments: {Arguments} | Time: {Time}",
                methodName, arguments, DateTime.Now);
        }

        protected override void OnAfter(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}";
            Log.Information("[LOG] OnAfter -> {Method} | Time: {Time}", methodName, DateTime.Now);
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            var methodName = $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}";
            Log.Error("[LOG] OnException -> {Method} | Exception: {Exception} | Time: {Time}",
                methodName, e.Message, DateTime.Now);
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}";
            Log.Information("[LOG] OnSuccess -> {Method} | Time: {Time}", methodName, DateTime.Now);
        }
    }
}
