<template>
    <div id="app">
        <Header />
        <Panel />
        <router-view />
        <Footer />
    </div>
</template>

<script>
    import Header from './components/HeaderPage.vue'
    import Footer from './components/FooterPage.vue'
    import Panel from './components/PanelPage.vue'
    import Home from './views/HomePage.vue'
    export default {
        components: {
            Header,
            Panel,
            Home,
            Footer
        }
    }
</script>

<style>
    #app {
        font-family: Arial, sans-serif;
    }
</style>
