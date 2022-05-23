<script setup>
  import WaterBill from './payments/WaterBill.vue';
  import RepairsBill from './payments/RepairsBill.vue';
  import RentBill from './payments/RentBill.vue';
  import AdditionalBill from './payments/AdditionalBill.vue';
  import ElecricityBill from './payments/ElecricityBill.vue';
  import HeatingBill from './payments/HeatingBill.vue';

  const payments = {
    elecricity: {
      payment: {
        value: 843.00,
        diff: -50,
      },
      consumptionReadings: {
        value: 10238,
        diff: 220
      },
      previousConsumptionReadings: {
        value: 10048,
        diff: 183
      }
    },
    water: {
      payment: {
        value: 600.00,
        diff: -300,
      },
      hotReadings: {
        value: 235,
        diff: 7
      },
      previousHotReadings: {
        value: 228,
        diff: 6
      },
      coldReadings: {
        predictedValue: 356
      },
      previousColdReadings: {
        value: 350,
        diff: 5
      },
    },
    heating: {
      payment: {
        value: 822.00,
        diff: -647,
      }
    },
    additional: {
      payment: {
        value: 1238.00,
        diff: 113,
      },
      internet: {
        value: 450.00,
        diff: 0
      }
    },
    repairs: {
      payment: {
        value: 384.00,
        diff: 0
      }
    },
    rent: {
      payment: {
        value: 13000.00,
        diff: 0
      }
    }
  };

  defineProps({
    isReadonly: Boolean
  });
</script>

<template>
  <h1>Payments</h1>
  <div class="payments">
    <ElecricityBill class="payments__item" :isReadonly="isReadonly" :bill="payments.elecricity" />
    <WaterBill class="payments__item" :isReadonly="isReadonly" :bill="payments.water" />
    <HeatingBill class="payments__item" :isReadonly="isReadonly" :bill="payments.heating" />
    <AdditionalBill class="payments__item" :isReadonly="isReadonly" :bill="payments.additional" />
    <RepairsBill class="payments__item" :isReadonly="isReadonly" :bill="payments.repairs" />
    <RentBill class="payments__item" :isReadonly="isReadonly" :bill="payments.rent" />
  </div>
</template>
<style>
  .payments {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    width: 100%;
    height: 100%;
    justify-content: space-evenly;
  }

  .payments__item {
    border: 1px solid grey;
    border-radius: 1px;
    flex: 1 1 15%;
    margin: 10px;
    padding: 20px;
  }

  .bill {
    display: flex;
    flex-direction: column;
  }
</style>