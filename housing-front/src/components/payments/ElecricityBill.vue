<script setup>
  import { ref } from 'vue';
  import { appService } from '../../core/appService';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean,
      bill: Object
  });
  
  const bill = ref(null);
  appService.getElecticityBill().then(v => bill.value = v);

  defineExpose({
    bill: Object
  });
</script>

<template>
  <div class="bill" v-if="bill">
    <i class="fa-solid fa-plug-circle-bolt"></i>
    <h3>Electricity</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="bill.payment"
      :isCurrency="true" />

    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Consumption readings'"
      :data="bill.consumptionReadings" />

    <PaymentEditableField
      :isReadonly="true"
      :title="'Previous readings'"
      :data="bill.previousConsumptionReadings" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: cyan;
  }
</style>