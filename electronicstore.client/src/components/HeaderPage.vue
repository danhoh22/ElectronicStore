<template>
    <header class="header">
        <div class="location">
            <img src="../assets/location-icon.png" alt="Location Icon" class="location-icon">
            <span class="city"></span>
            <span class="city-name">{{ cityName }}</span>
            <div class="logo">EStore</div>
        </div>
        <nav class="nav">
            <router-link to="/" class="nav-link">Акции</router-link>
            <router-link to="/Product" class="nav-link">Магазины</router-link>
            <router-link to="/cart" class="nav-link">8 800 555 35 35</router-link>
        </nav>
    </header>
</template>

<script>
    export default {
        data() {
            return {
                cityName: 'Киров', // Здесь можно использовать логику для определения города на основе геолокации
            }
        }
    }
</script>

<style>
    .header {
        color: #333; /* темный цвет текста */
        padding: 1rem;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    /* Стили для кнопки каталога */
    .catalog-button {
        background-color: transparent;
        border: none;
        cursor: pointer;
        margin-right: 1rem; /* Добавляем небольшой отступ справа */
    }

    /* Стили для блока каталога */
    .catalog {
        border: 1px solid #333; /* Пример рамки вокруг каталога */
        padding: 1rem;
        margin-top: 1rem; /* Добавляем небольшой отступ сверху */
    }
    .logo {
        font-size: 1.5rem;
        margin-left: 10px;
    }

    .nav {
        display: flex;
    }

    .nav-link {
        color: #333; /* темный цвет текста */
        margin-left: 1rem;
        text-decoration: none;
    }

        .nav-link:hover {
            text-decoration: underline;
        }

    .location {
        display: flex;
        align-items: center;
    }

    .location-icon {
        width: 20px; /* задаем размер значка геолокации */
        height: 20px;
        margin-right: 5px;
    }

    .city {
        font-weight: bold; /* делаем название города жирным */
        margin-right: 5px;
    }

    .city-name {
        font-style: italic; /* делаем название города курсивным */
    }
</style>
