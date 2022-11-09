import * as ethers from "ethers";
import { Transaction } from "ethereumjs-tx";

window.test = () => " From JS ";

window.sendBaseTokenAsync = async (sendBaseTokenParams) => {
    const provider = new ethers.providers.JsonRpcProvider(sendBaseTokenParams.ProviderRpcUrl);
    const gasLimit = ethers.utils.hexlify(sendBaseTokenParams.GasLimit ?? 21000);
    const gasPrice = ethers.utils.hexlify(sendBaseTokenParams.GasPrice);
    const nonce = await provider.getTransactionCount(sendBaseTokenParams.FromAddress);

    const tx = new Transaction({
        nonce: ethers.utils.hexlify(nonce),
        value: ethers.utils.parseEther(sendBaseTokenParams.AmountEth).toHexString(),
        to: sendBaseTokenParams.ToAddress,
        gasLimit,
        gasPrice,
    });

    return tx.serialize().toString('hex');
};