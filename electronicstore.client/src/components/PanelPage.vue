<template>
    <div class="home-page">
        <!-- Добавляем кнопку для раскрытия каталога -->
        <button @click="toggleCatalog" :class="{ 'catalog-button': true, 'open': showCatalog }">Каталог</button>
        <!-- Раздел для каталога продуктов -->
        <transition name="fade">
            <div v-if="showCatalog" class="catalog-container">
                <div class="catalog">
                    <div class="catalog-header">
                        <h2 class="catalog-title">Каталог продуктов</h2>
                        <button @click="closeCatalog" class="close-button">&times;</button>
                    </div>
                    <ul class="catalog-list">
                        <!-- Здесь размещается ваш список категорий -->
                        <li v-for="productCategory in categories" :key="productCategory.id" class="catalog-item">
                            <router-link @click="closeCatalog" :to="`/productCategory/${productCategory.productCategoryId}`" class="catalog-link">{{ productCategory.productCategoryName }}</router-link>
                        </li>
                    </ul>
                </div>
            </div>
        </transition>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                showCatalog: false,
                categories: []
            };
        },
        created() {
            this.fetchCategories();
            this.$router.afterEach(() => {
                this.closeCatalog();
            });
        },
        methods: {
            fetchCategories() {
                fetch('productcategory')
                    .then(response => response.json())
                    .then(data => {
                        this.categories = data;
                    })
                    .catch(error => {
                        console.error('Error fetching categories:', error);
                    });
            },
            toggleCatalog() {
                this.showCatalog = !this.showCatalog;
            },
            closeCatalog() {
                this.showCatalog = false;
            },
            // Метод обработки клика по категории продуктов
            handleCategoryClick(category) {
                console.log('Clicked category:', category);
                // Здесь можно реализовать дополнительные действия при выборе категории
                // Например, загрузить продукты этой категории и т.д.
            }
        }
    };
</script>


<style scoped>
    .home-page {
        position: relative;
        padding: 20px;
    }

    /* Стили для кнопки каталога */
    .catalog-button {
        background-color: #007bff;
        color: #fff;
        border: none;
        padding: 10px 30px;
        font-size: 16px;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
        position: relative; /* Добавляем позиционирование для псевдоэлементов */
    }

        /* Псевдоэлемент, который содержит треугольник */
        .catalog-button::before {
            content: '';
            position: absolute;
            top: 55%;
            left: 93px; /* Отступ справа от текста */
            transform: translateY(-50%);
            width: 0;
            height: 0;
            border-style: solid;
            border-width: 7px 7px 0 7px; /* Размеры треугольника */
            border-color: #fff transparent transparent transparent; /* Цвета граней треугольника */
            transition: transform 0.3s ease; /* Добавляем анимацию */
        }

        /* Псевдоэлемент, который содержит треугольник при открытом каталоге */
        .catalog-button.open::before {
            transform: translateY(-50%) rotate(180deg); /* Поворачиваем треугольник */
        }


        .catalog-button:hover {
            background-color: #0056b3;
        }

    .catalog-container {
        position: absolute;
        top: calc(100% + 10px);
        left: 0;
        background-color: #fff;
        box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.1);
        border-radius: 5px;
        padding: 20px;
        display: flex;
        flex-direction: column;
        align-items: flex-start;
        z-index: 1000;
    }

    .catalog-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        width: 100%;
        margin-bottom: 10px;
    }

    .catalog-title {
        margin: 0;
        font-size: 24px;
        color: #333;
    }

    .close-button {
        background: none;
        border: none;
        cursor: pointer;
        font-size: 24px;
        color: #999;
    }

        .close-button:hover {
            color: #333;
        }

    .catalog-list {
        list-style-type: none;
        padding: 0;
        margin: 0;
    }

    .catalog-item {
        margin-bottom: 10px;
    }

    .catalog-link {
        color: #333;
        text-decoration: none;
        font-size: 18px;
    }

        .catalog-link:hover {
            color: #007bff;
        }

    /* Анимация для открытия и закрытия каталога */
    .fade-enter-active, .fade-leave-active {
        transition: opacity 0.5s;
    }

    .fade-enter, .fade-leave-to {
        opacity: 0;
    }
</style>
