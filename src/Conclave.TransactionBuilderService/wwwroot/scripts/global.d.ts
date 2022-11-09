import { SendBaseTokenTxDto } from "./Types/SendBaseTokenTxDto";
import { SerializedTransactionHex } from "./Types/SerializedTransactionHex";

export { }
declare global {
    interface Window {
        test: () => string,
        sendBaseTokenAsync: (sendBaseTokenParams: SendBaseTokenTxDto) => Promise<SerializedTransactionHex>;
    }
}