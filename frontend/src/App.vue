<template>
  <p>Hello World!</p>
  <div v-for="p in data" :key="p.key">
    <p>{{ p.key }} - {{ p.value }}</p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      post: []
    }
  },
  methods: {
    getPosts() {
      fetch('http://localhost/Redis?key=deneme'), { mode: 'no-cors' }
        .then(response => {
          console.log(response)
          return response.json()
        } )
        .then(data => this.data = data)
    }
  },
  mounted() {
    this.getPosts()
  }
}
</script>
