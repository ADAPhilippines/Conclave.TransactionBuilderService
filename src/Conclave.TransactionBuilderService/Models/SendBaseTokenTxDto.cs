namespace Conclave.TransctionBuilderService.Models;

public record SendBaseTokenTxDto(
    string AmountEth,
    string ToAddress,
    ulong GasLimit,
    ulong GasPrice,
    ulong Nonce,
    ulong Chainid
);