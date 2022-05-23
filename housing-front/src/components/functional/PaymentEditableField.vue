<script setup>
  import ReadonlyField from './ReadonlyField.vue';
  import Differences from './Differences.vue';

  defineProps({
    data: Object,
    title: String,
    isReadonly: Boolean,
    isCurrency: Boolean
  });
</script>

<template>
  <div class="field">
    <div class="field__main">
      <span class="field__title">{{ title }}:</span>
      <ReadonlyField v-if="isReadonly" :title="title" :value="data.value" :showCurrency="isCurrency" />
      <div v-else class="payment__input">
        <input type="number" v-model="data.value" :placeholder="data.predictedValue"/>
      </div>
    </div>
    <Differences :diff="data.diff" :needNormalize="isCurrency" />
  </div>
</template>

<style scoped lang="scss">
  .field {
    display: flex;
    justify-content: space-between;
    margin-top: 50px;
  }

  .field__main {
    display: flex;
    border-bottom: 1px solid #bdbdbd;
    width: 100%;
  }
  
  .field__title {
    font-weight: bold;
    text-align: left;
    width: 450px;
  }

  .payment__input {
    margin-left: 5px;
  }
</style>