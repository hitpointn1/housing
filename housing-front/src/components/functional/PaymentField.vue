<script setup>
  import ReadonlyField from './ReadonlyField.vue';
  import Differences from './Differences.vue';

  defineProps({
    title: String,
    amount: Object
  });
</script>

<template>
  <div class="payment__field">
    <span class="field__title">{{ title }}:</span>
    <ReadonlyField :value="amount.value" :showCurrency="true" />
    <Differences :diff="amount.diff" :needNormalize="true" />
  </div>
</template>

<style scoped lang="scss">
  .payment__field {
    display: flex;
  }

  .field__title {
    font-weight: bold;
  }
</style>