<template>
    <div>
        <h2>Продукты</h2>
        <!-- Здесь размещаем список продуктов -->
        <div v-for="product in products" :key="product.id">
            <h3>{{ product.name }}</h3>
            <p>Цена: {{ product.price }}</p>
            <!-- Дополнительные детали продукта -->
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                products: [
                    { id: 1, name: 'Ноутбук', price: 1000 },
                    { id: 2, name: 'Смартфон', price: 500 },
                    // Добавьте здесь другие продукты
                ]
            }
        }
    }
</script>

<style scoped>
    /* Стили для списка продуктов */
</style>
