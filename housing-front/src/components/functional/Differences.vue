<script setup>
  import { computed } from '@vue/reactivity';

  const props = defineProps({
    diff: Number,
    needNormalize: Boolean
  });

  const diffNormalized = computed(() => props.needNormalize ? Math.abs(props.diff ?? 0).toFixed(2) : Math.abs(props.diff ?? 0).toString());
</script>

<template>
    <div v-if="diff < 0" class="field__diff field__diff--dec">
      <i class="fa-solid fa-angles-down"></i>
      <span>{{ diffNormalized }}</span>
    </div>

    <div v-else-if="diff > 0" class="field__diff field__diff--inc">
      <i class="fa-solid fa-angles-up"></i>
      <span>{{ diffNormalized }}</span>
    </div>
</template>

<style scoped lang="scss">
  .field__diff {
    font-size: xx-large;
    display: flex;
    justify-content: space-between;
    margin-left: 10px;
    
    i {
        font-size: small;
    }

    span {
        margin-left: 5px;
    }
  }

  .field__diff--inc {
    color: $red-color;
  }

  .field__diff--dec {
    color: $green-color;
  }
</style>