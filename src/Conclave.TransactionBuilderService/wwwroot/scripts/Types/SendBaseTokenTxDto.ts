export type SendBaseTokenTxDto = {
    AmountEth?: string,
    FromAddress?: string,
    ToAddress?: string,
    GasLimit?: bigint,
    GasPrice?: bigint,
    ProviderRpcUrl?: string
}