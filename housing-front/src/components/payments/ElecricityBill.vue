<script setup>
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean,
      bill: Object
  })
</script>

<template>
  <div class="bill">
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
      :isReadonly="isReadonly"
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