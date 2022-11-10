import * as ethers from "ethers";
import { Transaction } from "ethereumjs-tx";

window.test = () => " From JS ";

window.sendBaseTokenAsync = async (sendBaseTokenParams) => {
    const gasLimit = ethers.utils.hexlify(sendBaseTokenParams.gasLimit ?? 21000);
    const gasPrice = ethers.utils.hexlify(sendBaseTokenParams.gasPrice);

    const tx = new Transaction({
        nonce: ethers.utils.hexlify(sendBaseTokenParams.nonce),
        value: ethers.utils.parseEther(sendBaseTokenParams.amountEth).toHexString(),
        to: sendBaseTokenParams.toAddress,
        gasLimit,
        gasPrice,
    });

    return tx.serialize().toString('hex');
};