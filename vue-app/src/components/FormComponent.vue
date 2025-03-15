<template>
    <div class="form-container">
        <h2>Contact Form</h2>
        <form @submit.prevent="submitForm">
            <div class="form-group mb-3">
                <label class="form-label">Name:</label>
                <input type="text" v-model="form.name" class="form-control form-control-sm" required />
            </div>

            <div class="mb-3">
                <label class="form-label">Country:</label>
                <select v-model="form.country" class="form-select form-select-sm" required>
                    <option value="">Select a country</option>
                    <option value="USA">USA</option>
                    <option value="Canada">Canada</option>
                    <option value="UK">UK</option>
                    <option value="UAE">UAE</option>
                </select>
            </div>

            <div class="mb-3">
                <label class="form-label">Date of Birth:</label>
                <input type="date" v-model="form.dateOfBirth" class="form-control form-control-sm" required />
            </div>

            <div class="mb-3">
                <label class="form-label">Gender:</label>
                <div class="d-flex gap-3">
                    <div class="form-check">
                        <input type="radio" id="male" v-model="form.gender" value="Male" class="form-check-input"
                            required />
                        <label for="male" class="form-check-label">Male</label>
                    </div>
                    <div class="form-check">
                        <input type="radio" id="female" v-model="form.gender" value="Female" class="form-check-input" />
                        <label for="female" class="form-check-label">Female</label>
                    </div>
                    <div class="form-check">
                        <input type="radio" id="other" v-model="form.gender" value="Other" class="form-check-input" />
                        <label for="other" class="form-check-label">Other</label>
                    </div>
                </div>
            </div>

            <div class="mb-3">
                <label class="form-label">Interests:</label>
                <div class="d-flex gap-3">
                    <div class="form-check">
                        <input type="checkbox" id="sports" v-model="form.interests" value="Sports"
                            class="form-check-input" />
                        <label for="sports" class="form-check-label">Sports</label>
                    </div>
                    <div class="form-check">
                        <input type="checkbox" id="music" v-model="form.interests" value="Music"
                            class="form-check-input" />
                        <label for="music" class="form-check-label">Music</label>
                    </div>
                    <div class="form-check">
                        <input type="checkbox" id="travel" v-model="form.interests" value="Travel"
                            class="form-check-input" />
                        <label for="travel" class="form-check-label">Travel</label>
                    </div>
                </div>
            </div>

            <div class="d-flex justify-content-end">
                <button type="submit" class="btn btn-primary" :disabled="isSubmitting">Submit</button>
            </div>
            <p v-if="error" class="text-danger mt-3">{{ error }}</p>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    data() {
        return {
            form: { name: '', country: '', dateOfBirth: '', gender: '', interests: [] },
            isSubmitting: false,
            error: ''
        }
    },
    methods: {
        async submitForm() {
            if (!this.validateForm()) return
            this.isSubmitting = true
            try {
                await axios.post('/api/submissions', this.form)
                alert('Form submitted successfully!')
                this.resetForm()
            } catch (err) {
                this.error = 'Failed to submit form: ' + err.message
            } finally {
                this.isSubmitting = false
            }
        },
        validateForm() {
            if (!this.form.name) return this.showError('Name is required')
            if (!this.form.country) return this.showError('Country is required')
            if (!this.form.dateOfBirth) return this.showError('Date of Birth is required')
            if (!this.form.gender) return this.showError('Gender is required')
            this.error = ''
            return true
        },
        showError(msg) {
            this.error = msg
            return false
        },
        resetForm() {
            this.form = { name: '', country: '', dateOfBirth: '', gender: '', interests: [] }
        }
    }
}
</script>