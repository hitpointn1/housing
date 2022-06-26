<script setup>
  import { computed } from '@vue/reactivity';
  import { onMounted, ref } from 'vue';

  const props = defineProps({
    options: Object,
    modelValue: Number
  });

  const emit = defineEmits(['update:modelValue', 'change']);

  let defaultValue;

  onMounted(() => {
    defaultValue = props.modelValue;
  });

  const isOpen = ref(false);
  const mouseOverList = ref(false);
  const selected = computed(() => Object.keys(props.options).find(k => props.options[k] === props.modelValue));

  const changeMouseOver = () => {
    if (isOpen.value) {
      return;
    }
    mouseOverList.value = false;
  }

  const itemSelect = (option) => {
    isOpen.value = false;
    changeMouseOver();
    changeEmits(props.options[option]);
  }

  const toggleList = () => {
    isOpen.value = !isOpen.value;
    changeMouseOver();
  }

  const selectedClear = () => {
    changeEmits(defaultValue);
  }

  const changeEmits = (option) => {
    emit('update:modelValue', option);
    emit('change', option);
  }

  const hoverOverItem = () => {
    if (!isOpen.value) {
      return;
    }
    mouseOverList.value = true;
  }

</script>

<template>
  <div class="dropdown">

    <div class="dropdown__box" @click="toggleList">
      <span>{{ selected }}</span>
      <span>
        <i v-show="!isOpen && modelValue" class="fa-solid fa-xmark" @click.stop.prevent="selectedClear"></i>
        <i :class="isOpen ? 'fa-solid fa-angle-down reversed' : 'fa-solid fa-angle-down' "></i>
      </span>
    </div>

    <transition name="slide-fade">
      <ul v-show="isOpen">
        <li v-for="option in Object.keys(options)"
          @click="() => itemSelect(option)"
          :class="mouseOverList ? '' : modelValue === options[option] ? 'selected' : ''"
          @mouseenter="hoverOverItem"
        >
        {{ option }}
        </li>
      </ul>
    </transition>
    
  </div>
</template>

<style scoped lang="scss">
  .dropdown {
    position: relative;
    box-sizing: border-box;
    width: 100%;

    .dropdown__box {
      display: flex;
      justify-content: space-between;
      padding: 0;
      border-radius: 5px;
      border: 1px solid grey;
      width: 100%;
      height: 60px;

      span {
        padding: 5px 10px;
        user-select: none;
        display: flex;
        align-items: center;
      }

      .fa-angle-down {
        margin-right: 5px;
        font-size: 30px;
        transition: transform 0.3s;
        cursor: pointer;
      }

      .fa-xmark {
        margin-right: 10px;
        font-size: 20px;
        cursor: pointer;
      }

      .reversed {
        transform: rotate(180deg);
      }
    }
    .slide-fade-enter-active {
      transition: all 0.3s ease-out;
    }

    .slide-fade-leave-active {
      transition: all 0.3s cubic-bezier(1, 0.5, 0.8, 1);
    }

    .slide-fade-enter-from,
    .slide-fade-leave-to {
      opacity: 0;
    }

    ul {
      list-style-type: none;
      margin: 0;
      padding: 0;
      position: absolute;
      width: 100%;
      border: 1px solid grey;
      border-radius: 0 0 5px 5px;
      z-index: 10;
      background-color: white;

      li {
        cursor: pointer;
        user-select: none;
        padding: 5px 0;
      }
      
      li.selected,
      li:hover {
        background-color: darken(white, 20%);
      }

      li:last-child {
        border-radius: 0 0 5px 5px;
      }
    }
   
  }
  
</style>