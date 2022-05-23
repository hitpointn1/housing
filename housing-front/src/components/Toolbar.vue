<script setup>

  defineProps({
    isReadonly: Boolean
  });

</script>

<template>
  <div class="toolbar">
    <i class="fa-solid fa-calendar"></i>
    <i class="fa-solid fa-file-excel"></i>
    <i v-if="isReadonly" class="fa-solid fa-pen-to-square" @click="() => $emit('edit')"></i>
    <i v-else class="fa-solid fa-floppy-disk" @click="() => $emit('save')"></i>
  </div>
</template>

<style scoped lang="scss">
  .toolbar {
    display: flex;
    justify-content: flex-end;

    .fa-file-excel {
      color: $green-color;
    }

    .fa-calendar {
      color: $blue-color;
    }

    i {
      margin-left: 10px;
    }

    i:hover {
      cursor: pointer;
    }
  }
</style>