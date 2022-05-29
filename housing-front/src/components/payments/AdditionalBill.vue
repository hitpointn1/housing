<script setup>
  import { ref } from 'vue';
  import { appService } from '../../core/appService';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean,
      bill: Object
  });
  
  const bill = ref(null);
  appService.getAdditionalBill().then(v => bill.value = v);

  defineExpose({
    bill: Object
  });
</script>

<template>
  <div class="bill" v-if="bill">
    <i class="fa-solid fa-warehouse"></i>
    <h3>Elevator, guards, internet, ... etc</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="bill.payment"
      :isCurrency="true" />

    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'internet'"
      :data="bill.internet"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: goldenrod;
  }
</style>