<script setup>
  import { ref } from 'vue';
  import { appService } from '../../core/appService';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean
  });

  const bill = ref(null);
  appService.getWaterBill().then(v => bill.value = v);

  defineExpose({
    bill: Object
  });
</script>

<template>
  <div class="bill" v-if="bill">
    <i class="fa-solid fa-droplet"></i>
    <h3>Water</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="bill.payment"
      :isCurrency="true" />

    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Hot water readings'"
      :data="bill.hotReadings" />
      
    <PaymentEditableField
      :isReadonly="true"
      :title="'Previous hot'"
      :data="bill.previousHotReadings" />

    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Cold water readings'"
      :data="bill.coldReadings" />

    <PaymentEditableField
      :isReadonly="true"
      :title="'Previous cold'"
      :data="bill.previousColdReadings" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: $blue-color;
  }
</style>