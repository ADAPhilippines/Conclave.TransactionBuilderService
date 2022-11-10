export type SendBaseTokenTxDto = {
    amountEth?: string,
    fromAddress?: string,
    toAddress?: string,
    gasLimit?: bigint,
    gasPrice?: bigint,
    nonce?: bigint
}