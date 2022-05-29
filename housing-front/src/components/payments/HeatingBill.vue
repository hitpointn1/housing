<script setup>
  import { ref } from 'vue';
  import { appService } from '../../core/appService';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean,
      bill: Object
  });
  
  const bill = ref(null);
  appService.getHeatingBill().then(v => bill.value = v);

  defineExpose({
    bill: Object
  });
</script>

<template>
  <div class="bill" v-if="bill">
    <i class="fa-solid fa-temperature-arrow-up"></i>
    <h3>Heating</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="bill.payment"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: $red-color;
  }
</style>