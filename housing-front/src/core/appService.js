import { actions } from "./helpers/actions";
import { httpService } from "./httpService";

const getSummary = (reportDate, reportType) => {
    return httpService.get(actions.getSummaryAction(reportDate, reportType));
}

const getWaterBill = (reportDate, reportType) => {
    return httpService.get(actions.getWaterBillAction(reportDate, reportType));
}

const getRentBill = (reportDate, reportType) => {
    return httpService.get(actions.getRentBill(reportDate, reportType));
}

const getRepairsBill = (reportDate, reportType) => {
    return httpService.get(actions.getRepairsBill(reportDate, reportType));
}

const getHeatingBill = (reportDate, reportType) => {
    return httpService.get(actions.getHeatingBill(reportDate, reportType));
}

const getElecticityBill = (reportDate, reportType) => {
    return httpService.get(actions.getElecticityBill(reportDate, reportType));
}

const getAdditionalBill = (reportDate, reportType) => {
    return httpService.get(actions.getAdditionalBill(reportDate, reportType));
}

export const appService = {
    getSummary,
    getWaterBill,
    getRentBill,
    getRepairsBill,
    getHeatingBill,
    getElecticityBill,
    getAdditionalBill
};


