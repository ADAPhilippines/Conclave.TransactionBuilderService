import * as ethers from "ethers";
window.test = () => " From JS ";

window.sendBaseTokenAsync = async (sendBaseTokenParams) => {
    const gasLimit = ethers.utils.hexlify(sendBaseTokenParams.gasLimit ?? 21000);
    const gasPrice = ethers.utils.hexlify(ethers.utils.parseUnits(sendBaseTokenParams.gasPrice.toString(), 'gwei'));
    return ethers.utils.serializeTransaction({
        chainId: sendBaseTokenParams.chainId,
        value: ethers.utils.parseEther(sendBaseTokenParams.amountEth).toHexString(),
        to: sendBaseTokenParams.toAddress,
        gasLimit,
        gasPrice,
        nonce: sendBaseTokenParams.nonce
    });
};