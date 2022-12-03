using ITS.Infrastructure.Enums;

namespace ITS.Infrastructure.Helpers
{
    /// <summary>
    /// کلاس هلپر عملیات
    /// </summary>
    public class OperationHelper
    {
        /// <summary>
        /// نتیجه عملیات به مقادیر بولین
        /// </summary>
        /// <param name="value">نوع عملیات</param>
        /// <returns>بولین</returns>
        public static bool OperationResultToBoolean(OperationResult value)
        {
            return value == OperationResult.Success;
        }

        /// <summary>
        /// مقدار بولین به نتیجه عملیات
        /// </summary>
        /// <param name="value">مقدار بولین</param>
        /// <returns>نتیجه عملیات</returns>
        public static OperationResult BooleanToOperationResult(bool value)  
        {
            return value ? OperationResult.Success : OperationResult.Fail;
        }
    }
}