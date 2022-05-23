<script setup>
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean,
      bill: Object
  })
</script>

<template>
  <div class="bill">
    <i class="fa-solid fa-building-user"></i>
    <h3>Rent</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Rent amount'"
      :data="bill.payment"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: purple;
  }
</style>