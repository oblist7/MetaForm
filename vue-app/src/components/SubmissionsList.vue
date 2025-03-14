<template>
    <div class="list-container">
        <h2>Submissions</h2>
        <div class="search">
            <input v-model="searchField" placeholder="Field (e.g., name)" />
            <input v-model="searchValue" placeholder="Value (e.g., John)" />
            <button @click="searchSubmissions">Search</button>
        </div>
        <ul>
            <li v-for="submission in submissions" :key="submission.id">
                <pre>{{ JSON.parse(submission.data) }}</pre>
            </li>
        </ul>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    data() {
        return {
            submissions: [],
            searchField: '',
            searchValue: ''
        };
    },
    async created() {
        await this.fetchSubmissions();
    },
    methods: {
        async fetchSubmissions() {
            const response = await axios.get('/api/submissions');
            this.submissions = response.data;
        },
        async searchSubmissions() {
            if (!this.searchField || !this.searchValue) {
                await this.fetchSubmissions();
                return;
            }
            const response = await axios.get('/api/submissions/search', {
                params: { field: this.searchField, value: this.searchValue }
            });
            this.submissions = response.data;
        }
    }
};
</script>

<style scoped>
.list-container {
    max-width: 800px;
    margin: 20px auto;
    padding: 20px;
}

.search {
    margin-bottom: 20px;
}

.search input {
    padding: 8px;
    margin-right: 10px;
}

button {
    padding: 8px 16px;
    background: #007bff;
    color: white;
    border: none;
}

ul {
    list-style: none;
    padding: 0;
}

li {
    border: 1px solid #ccc;
    padding: 10px;
    margin-bottom: 10px;
}

pre {
    margin: 0;
}
</style>