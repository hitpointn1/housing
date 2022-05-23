<script setup>
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean,
      bill: Object
  })
</script>

<template>
  <div class="bill">
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