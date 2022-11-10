namespace Conclave.TransctionBuilderService.Models;

public record SendBaseTokenTxDto(
    string AmountEth,
    string FromAddress,
    string ToAddress,
    ulong GasLimit,
    ulong GasPrice,
    ulong Nonce
);