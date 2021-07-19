<template>
  <div>
    <button @click="getFoodPlaces">
      YUM YUM OPTIONS
    </button>
    <div v-for="f in foodplaces" :key="f.id">
      {{ f.name }}
    </div>
  </div>
</template>

<script>
import { ref } from '@vue/reactivity'
import { api } from '../services/AxiosService'
export default {
  name: 'Home',
  setup() {
    const foodplaces = ref([])

    return {
      foodplaces,
      async getFoodPlaces() {
        const res = await api.get('api/foodplaces')
        foodplaces.value = res.data
      }
    }
  }
}
</script>

<style scoped lang="scss">

</style>
