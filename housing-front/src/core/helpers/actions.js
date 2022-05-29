import { urlBuilder } from "./urlBuilder";

const summaryController = 'summary';
const billsController = 'bills';
const date = new Date();

function getActionUrl(controller, method) {
    const endpoint = controller + '/'; 
    const url = method ? endpoint + method + '/' : endpoint;
    const builder = urlBuilder(url);

    builder.withRoute(date.getFullYear());
    builder.withRoute((date.getMonth() + 1));
    builder.withParameter('type', null);

    return builder.build();
}

export const actions = {
    getSummaryAction: getActionUrl(summaryController),
    getWaterBillAction: getActionUrl(billsController, 'water'),
    getRentBill: getActionUrl(billsController, 'rent'),
    getRepairsBill: getActionUrl(billsController, 'repairs'),
    getHeatingBill: getActionUrl(billsController, 'heating'),
    getElecticityBill: getActionUrl(billsController, 'electricity'),
    getAdditionalBill: getActionUrl(billsController, 'additional')
};
