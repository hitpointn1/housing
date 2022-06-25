<script setup>
  import { onUpdated, ref } from 'vue';

  const props = defineProps({
    show: Boolean
  });

  const dialog = ref(null);

  onUpdated(() => {
    if (props.show) {
      dialog.value.focus();
    }
  });

</script>

<template>
  <div ref="dialog" class="dialog" v-if="show" tabindex='1' @keyup.esc="() => $emit('onClose')">
    <div class="dialog__content">
      <i class="fa-solid fa-circle-xmark close" @click="() => $emit('onClose')"></i>
      <slot></slot>
    </div>
  </div>
</template>

<style scoped lang="scss">
  .dialog {
    position: fixed;
    z-index: 1;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    overflow: auto;
    background-color: rgba(0,0,0,0.4);
    outline: none;
    
    .dialog__content {
      min-height: 100px;
      min-width: 100px;
      background-color: #fefefe;
      margin: 15% auto;
      padding: 20px;
      border: 1px solid #888;
      width: 450px;
    }

    .close {
      color: #aaa;
      float: right;
      font-size: 28px;
      font-weight: bold;
    }

    .close:hover,
    .close:focus {
      color: $red-color;
      text-decoration: none;
      cursor: pointer;
    }
  }

</style>