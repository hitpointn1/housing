<script setup>
  import WaterBill from './payments/WaterBill.vue';
  import RepairsBill from './payments/RepairsBill.vue';
  import RentBill from './payments/RentBill.vue';
  import AdditionalBill from './payments/AdditionalBill.vue';
  import ElecricityBill from './payments/ElecricityBill.vue';
  import HeatingBill from './payments/HeatingBill.vue';

  defineProps({
    isReadonly: Boolean
  });
</script>

<template>
  <h1>Payments</h1>
  <div class="payments">
    <ElecricityBill class="payments__item" :isReadonly="isReadonly" />
    <WaterBill class="payments__item" :isReadonly="isReadonly" />
    <HeatingBill class="payments__item" :isReadonly="isReadonly" />
    <AdditionalBill class="payments__item" :isReadonly="isReadonly" />
    <RepairsBill class="payments__item" :isReadonly="isReadonly" />
    <RentBill class="payments__item" :isReadonly="isReadonly" />
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