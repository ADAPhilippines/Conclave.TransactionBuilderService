export type SendBaseTokenTxDto = {
    amountEth?: string,
    toAddress?: string,
    gasLimit?: bigint,
    gasPrice?: bigint,
    nonce?: number,
    chainId?: number
}