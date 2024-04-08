import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/HomePage.vue'
import Product from '../views/ProductsPage.vue'
import ProductDetails from '../views/ProductDetails.vue'
import ShoppingCart from '../views/ShoppingCart.vue'
import Panel from '../components/PanelPage.vue'
import ProductCategory from '../components/ProductDetails.vue'
const routes = [
    { path: '/productCategory/:id', component: ProductCategory },
    { path: '/', component: Home, Panel },
    { path: '/Product', component: Product },
    { path: '/products/:id', component: ProductDetails },
    { path: '/cart', component: ShoppingCart }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
