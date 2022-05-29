import { actions } from "./helpers/actions";
import { httpService } from "./httpService";

const getSummary = () => {
    return httpService.get(actions.getSummaryAction);
}

const getWaterBill = () => {
    return httpService.get(actions.getWaterBillAction);
}

const getRentBill = () => {
    return httpService.get(actions.getRentBill);
}

const getRepairsBill = () => {
    return httpService.get(actions.getRepairsBill);
}

const getHeatingBill = () => {
    return httpService.get(actions.getHeatingBill);
}

const getElecticityBill = () => {
    return httpService.get(actions.getElecticityBill);
}

const getAdditionalBill = () => {
    return httpService.get(actions.getAdditionalBill);
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


