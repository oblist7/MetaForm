<template>
    <div class="container">
        <h2 class="mb-2">Submissions</h2>

        <label class="form-label">Search:</label>
        <div class="input-group">
            <input v-model="searchField" class="form-control form-control-sm" placeholder="Field (e.g., name)" />
            <input v-model="searchValue" class="form-control form-control-sm" placeholder="Value (e.g., John)" />
            <button @click="searchSubmissions" class="btn btn-primary">Search</button>
        </div>

        <ul class="list-group">
            <li v-for="submission in submissions" :key="submission.id" class="list-group-item">
                <pre>{{ JSON.parse(submission.data) }}</pre>
            </li>
        </ul>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    data() {
        return {
            submissions: [],
            searchField: '',
            searchValue: ''
        }
    },
    async created() {
        await this.fetchSubmissions()
    },
    methods: {
        async fetchSubmissions() {
            const response = await axios.get('/api/submissions')
            this.submissions = response.data
        },
        async searchSubmissions() {
            if (!this.searchField || !this.searchValue) {
                await this.fetchSubmissions()
                return
            }
            const response = await axios.get('/api/submissions/search', {
                params: { field: this.searchField, value: this.searchValue }
            })
            this.submissions = response.data
        }
    }
}
</script>