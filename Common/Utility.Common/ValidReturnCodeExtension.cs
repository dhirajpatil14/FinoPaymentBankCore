namespace Utility.Common
{
    public static class ValidReturnCodeExtension
    {
        public static bool IsValidCode(int? returnCode)
        {
            return returnCode == 0;
        }
    }
}
