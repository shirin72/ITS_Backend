using System.ComponentModel;

namespace ITS.Infrastructure.Enums
{
    /// <summary>
    /// نتایج عملیات
    /// </summary>
    public enum OperationResult
    {
        [Description("عملیات با شکست مواجه شد")]
        Fail = 0,

        [Description("عملیات با موفقیت انجام شد")]
        Success = 1,
    }
}