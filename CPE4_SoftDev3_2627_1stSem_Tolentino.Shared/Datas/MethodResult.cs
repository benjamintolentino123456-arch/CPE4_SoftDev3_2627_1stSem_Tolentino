namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Datas
{
    public record MethodResult(bool IsSuccess, string? Error)
    {
        public static MethodResult Ok() => new(true, null);
        public static MethodResult Fail(string error) => new(false, error);
    }

    public record MethodResult<TData>(bool IsSuccess, TData Data, string? Error) 
    {
        public static MethodResult<TData> Ok(TData Data) => new(true, Data, null);
        public static MethodResult<TData> Fail(string error) => new(false, default(TData), error);
    }
}
