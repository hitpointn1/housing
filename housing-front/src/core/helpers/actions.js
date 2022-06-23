import { urlBuilder } from "./urlBuilder";

const summaryController = 'summary';
const billsController = 'bills';

function getActionUrl(reportDate, reportType, controller, method) {
    const endpoint = controller + '/'; 
    const url = method ? endpoint + method + '/' : endpoint;
    const builder = urlBuilder(url);

    builder.withRoute(reportDate.getFullYear());
    builder.withRoute((reportDate.getMonth() + 1));
    builder.withParameter('type', reportType);

    return builder.build();
}

export const actions = {
    getSummaryAction: (reportDate, reportType) => getActionUrl(reportDate, reportType, summaryController),
    getWaterBillAction: (reportDate, reportType) => getActionUrl(reportDate, reportType, billsController, 'water'),
    getRentBill: (reportDate, reportType) => getActionUrl(reportDate, reportType, billsController, 'rent'),
    getRepairsBill: (reportDate, reportType) => getActionUrl(reportDate, reportType, billsController, 'repairs'),
    getHeatingBill: (reportDate, reportType) => getActionUrl(reportDate, reportType, billsController, 'heating'),
    getElecticityBill: (reportDate, reportType) => getActionUrl(reportDate, reportType, billsController, 'electricity'),
    getAdditionalBill: (reportDate, reportType) => getActionUrl(reportDate, reportType, billsController, 'additional')
};
