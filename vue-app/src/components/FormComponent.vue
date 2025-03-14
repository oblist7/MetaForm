<template>
    <div class="form-container">
        <h2>Contact Form</h2>
        <form @submit.prevent="submitForm">
            <div class="form-group">
                <label>Name:</label>
                <input type="text" v-model="form.name" required />
            </div>
            <div class="form-group">
                <label>Country:</label>
                <select v-model="form.country" required>
                    <option value="">Select a country</option>
                    <option value="USA">USA</option>
                    <option value="Canada">Canada</option>
                    <option value="UK">UK</option>
                </select>
            </div>
            <div class="form-group">
                <label>Date of Birth:</label>
                <input type="date" v-model="form.dateOfBirth" required />
            </div>
            <div class="form-group">
                <label>Gender:</label>
                <div>
                    <label><input type="radio" v-model="form.gender" value="Male" required /> Male</label>
                    <label><input type="radio" v-model="form.gender" value="Female" /> Female</label>
                    <label><input type="radio" v-model="form.gender" value="Other" /> Other</label>
                </div>
            </div>
            <div class="form-group">
                <label>Interests:</label>
                <div>
                    <label><input type="checkbox" v-model="form.interests" value="Sports" /> Sports</label>
                    <label><input type="checkbox" v-model="form.interests" value="Music" /> Music</label>
                    <label><input type="checkbox" v-model="form.interests" value="Travel" /> Travel</label>
                </div>
            </div>
            <button type="submit" :disabled="isSubmitting">Submit</button>
            <p v-if="error" class="error">{{ error }}</p>
        </form>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    data() {
        return {
            form: {
                name: '',
                country: '',
                dateOfBirth: '',
                gender: '',
                interests: []
            },
            isSubmitting: false,
            error: ''
        };
    },
    methods: {
        async submitForm() {
            if (!this.validateForm()) return;
            this.isSubmitting = true;
            try {
                await axios.post('/api/submissions', this.form);
                alert('Form submitted successfully!');
                this.resetForm();
            } catch (err) {
                this.error = 'Failed to submit form: ' + err.message;
            } finally {
                this.isSubmitting = false;
            }
        },
        validateForm() {
            // Basic validation
            if (!this.form.name) {
                this.error = 'Name is required';
                return false;
            }
            if (!this.form.country) {
                this.error = 'Country is required';
                return false;
            }
            if (!this.form.dateOfBirth) {
                this.error = 'Date of Birth is required';
                return false;
            }
            if (!this.form.gender) {
                this.error = 'Gender is required';
                return false;
            }
            this.error = '';
            return true;
        },
        resetForm() {
            this.form = { name: '', country: '', dateOfBirth: '', gender: '', interests: [] };
        }
    }
};
</script>

<style scoped>
.form-container {
    max-width: 500px;
    margin: 20px auto;
    padding: 20px;
    border: 1px solid #ccc;
}

.form-group {
    margin-bottom: 15px;
}

label {
    display: block;
    margin-bottom: 5px;
}

input,
select {
    width: 100%;
    padding: 8px;
}

button {
    padding: 10px 20px;
    background: #007bff;
    color: white;
    border: none;
}

button:disabled {
    background: #ccc;
}

.error {
    color: red;
}
</style>