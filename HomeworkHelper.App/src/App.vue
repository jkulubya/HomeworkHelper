<template>
  <!--<div class="wrapper" @click="update">
    <image :src="logoUrl" class="logo"></image>
    <text class="title">Hello {{target}}</text>
  </div>-->
  <list class="list">
    <cell class="cell" v-for="question in questions">
      <text class="text">{{question.title}}</text>
      <text class="text">{{question.author}}</text>
    </cell>
  </list>
</template>

<style scoped>
  .panel {
    width: 600px;
    height: 300px;
    margin-left: 75px;
    margin-top: 35px;
    margin-bottom: 35px;
    flex-direction: column;
    justify-content: center;
    border-width: 2px;
    border-style: solid;
    border-color: rgb(162, 217, 192);
    background-color: rgba(162, 217, 192, 0.2);
  }
  .text {
    font-size: 88px;
    text-align: center;
    color: #41B883;
  }
</style>

<script>
  export default {
    data: {
      logoUrl: 'https://alibaba.github.io/weex/img/weex_logo_blue@3x.png',
      target: 'World',
      questions: [
        {
          author: "jkulubya",
          title: "What is x*y?"
        },
        {
          author: "enock",
          title: "What is a*b?"
        },
        {
          author: "jka",
          title: "What is b*y?"
        },
        {
          author: "jkulubya",
          title: "What is x*8*y?"
        }        
      ]
    },
    methods: {
      update: function (e) {
        this.target = 'Weex'
        console.log('target:', this.target)
      }
    }
  }
</script>
